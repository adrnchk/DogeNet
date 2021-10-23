using System;
using System.Collections.Generic;

#nullable disable
namespace DogeNet.DAL
{
    public partial class PostContent
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Url { get; set; }

        public virtual Post Post { get; set; }
    }
}
