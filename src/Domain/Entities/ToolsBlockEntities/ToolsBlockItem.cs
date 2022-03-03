using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Domain.Entities.ToolsBlockEntities;

public class ToolsBlockItem
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Version { get; set; }

    public string? Url { get; set; }

    public DateTime CreateTimeUtc { get; set; }

    public string? CommentContent { get; set; }

    public IReadOnlyList<CommentReply> CommentReplies { get; set; }
}
