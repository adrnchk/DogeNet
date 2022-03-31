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
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly DBContext context;

        public PostController(IMediator mediator, DBContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(PostDetailsModel))]
        public async Task<IActionResult> GetPostById(int id)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new GetPostQuery(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new CreatePostCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(PostDetailsModel))]
        public async Task<IActionResult> EditPost(EditPostModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new EditPostCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new DeletePostCommand(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

    }
}
