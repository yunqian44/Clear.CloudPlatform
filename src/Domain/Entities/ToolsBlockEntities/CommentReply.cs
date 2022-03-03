using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Domain.Entities.ToolsBlockEntities;

public class CommentReply
{
    public Guid Id { get; set; }

    public Guid CommentId { get; set; }

    public string? CommentContent { get; set; }

    public string? Title { get; set; }

    public DateTime CreateTimeUtc { get; set; }
}
