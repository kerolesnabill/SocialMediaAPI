using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace SocialMediaApplication.Posts.Commands.UpdatePost;

public class UpdatePostCommand : IRequest
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public IFormFileCollection? Images { get; set; }
}
