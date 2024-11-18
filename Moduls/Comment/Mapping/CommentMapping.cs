using System.Runtime.InteropServices.Marshalling;
using Npgsql.Replication;

public static class CommentMapping
{
    public static Comment ToCreate(this CreateCommentInfo comment)
    {
        return new()
        {
            Text = comment.BaseCommentInfo.Text,
            UserId = comment.BaseCommentInfo.UserId,
            VideoId = comment.BaseCommentInfo.VideoId
        };
    }

    public static Comment ToDelete(this Comment comment)
    {
        comment.DeletedAt = DateTime.UtcNow;
        comment.IsDeleted = true;
        return comment;
    }

    public static ReadCommentInfo ToRead(this Comment comment)
    {
        return new()
        {
            Id = comment.Id,
            CreatedAt = comment.CreatedAt,
            BaseCommentInfo = new BaseCommentInfo()
            {
                Text = comment.Text,
                UserId = comment.UserId,
                VideoId = comment.VideoId
            }
        };
    }
}