using AutoMapper;
using SocialMediaApplication.Comments.Commands.CreateComment;
using SocialMediaApplication.Comments.Commands.UpdateComment;
using SocialMediaDomain.Entities;

namespace SocialMediaApplication.Comments.Dtos;

public class CommentsProfile : Profile
{
    public CommentsProfile()
    {
        CreateMap<CreateCommentCommand, Comment>();
        CreateMap<UpdateCommentCommand, Comment>();
        CreateMap<Comment, CommentDto>();
    }
}
