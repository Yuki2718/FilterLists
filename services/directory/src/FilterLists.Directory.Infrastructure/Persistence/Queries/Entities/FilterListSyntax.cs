﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilterLists.Directory.Infrastructure.Persistence.Queries.Entities
{
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    public class FilterListSyntax
    {
        public int FilterListId { get; private set; }
        public FilterList FilterList { get; private set; } = null!;
        public int SyntaxId { get; private set; }
        public Syntax Syntax { get; private set; } = null!;
    }

    internal class FilterListSyntaxTypeConfiguration : IEntityTypeConfiguration<FilterListSyntax>
    {
        public virtual void Configure(EntityTypeBuilder<FilterListSyntax> builder)
        {
            _ = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(nameof(FilterListSyntax) + "es");

            builder.HasKey(fls => new {fls.FilterListId, fls.SyntaxId});
        }
    }
}