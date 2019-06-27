using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Data.Configurations
{
    public class BagConfiguration : EntityTypeConfiguration<Bag>
    {
        public BagConfiguration()
        {
            HasKey(b => b.Id);
        }
    }
}