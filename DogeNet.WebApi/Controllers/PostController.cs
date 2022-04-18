// <copyright file="PostController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Posts;
    using DogeNet.BLL.Features.Posts.CreatePost;
    using DogeNet.BLL.Features.Posts.DeletePost;
    using DogeNet.BLL.Features.Posts.EditPost;
    using DogeNet.BLL.Features.Posts.GetPost;
    using DogeNet.BLL.Middleware;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(PostDetailsModel))]
        public async Task<IActionResult> GetPostById(int id) =>
            this.Ok(await this.mediator.Send(new GetPostQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostModel model) =>
            this.Ok(await this.mediator.Send(new CreatePostCommand(model)));

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(PostDetailsModel))]
        public async Task<IActionResult> EditPost(EditPostModel model) => 
            this.Ok(await this.mediator.Send(new EditPostCommand(model)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id) =>
            this.Ok(await this.mediator.Send(new DeletePostCommand(id)));
    }
}
