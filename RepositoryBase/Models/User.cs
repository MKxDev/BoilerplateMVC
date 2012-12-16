﻿using System;

namespace RepositoryBase.Models
{
    public class User : BaseModel
    {
        public virtual string UserName { get; set; }
        public virtual string Salt { get; set; }
        public virtual string Hash { get; set; }
    }
}