﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Directory.Infrastructure.Persistence.Queries.Entities
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class SegmentViewUrl
    {
        public int Id { get; private set; }
        public int FilterListId { get; set; }
        public FilterList FilterList { get; private set; } = null!;
        public int Position { get; private set; }
        public Uri Url { get; private set; } = null!;
        public IReadOnlyCollection<SegmentViewUrlMirror> SegmentViewUrlMirrors { get; private set; } = new HashSet<SegmentViewUrlMirror>();
    }

    internal class ViewUrlPartialTypeConfiguration : IEntityTypeConfiguration<SegmentViewUrl>
    {
        public virtual void Configure(EntityTypeBuilder<SegmentViewUrl> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(nameof(SegmentViewUrl) + "s");

            builder.HasIndex(s => new {s.FilterListId, s.Position})
                .IsUnique();
        }
    }
}