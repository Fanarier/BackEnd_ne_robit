﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Fanarier_2.Models
{
    public partial class Acq
    {
        public int Id { get; set; }

        public int? ClientWomanId { get; set; }

        public int? ClientManId { get; set; }

        public DateTime? Date { get; set; }

        public bool? WomanAgr { get; set; }

        public bool? ManAgr { get; set; }

        [JsonIgnore]
        public virtual Client ClientMan { get; set; }

        [JsonIgnore]
        public virtual Client ClientWoman { get; set; }
    }
}
