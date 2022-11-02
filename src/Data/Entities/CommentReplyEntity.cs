using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Data.Entities;

public class CommentReplyEntity
{
    public Guid Id { get; set; }
    public string ReplyContent { get; set; }
    public DateTime CreateTimeUtc { get; set; }
    public Guid? CommentId { get; set; }

    public virtual ToolsBlockEntity Comment { get; set; }
}


