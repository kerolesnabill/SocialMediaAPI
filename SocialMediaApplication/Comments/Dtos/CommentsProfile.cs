using AutoMapper;
using SocialMediaApplication.Comments.CreateComment;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Comments.Dtos;

public class CommentsProfile : Profile
{
    public CommentsProfile()
    {
        CreateMap<CreateCommentCommand, Comment>();
        CreateMap<Comment, CommentDto>();
    }
}
