﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSSQLServerMonitoring.Domain.HangFireModel;

namespace MSSQLServerMonitoring.Infrastructure.Data.HangFireModel.EntityConfigurations
{
    public class HangFireCounterMap : IEntityTypeConfiguration<HangFireCounter>
    {
        public void Configure(EntityTypeBuilder<HangFireCounter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseHiLo();
        }
    }
}
