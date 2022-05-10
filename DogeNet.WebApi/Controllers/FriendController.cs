// <copyright file="FriendController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Friends.AddFriend;
    using DogeNet.BLL.Features.Friends.DeleteFriend;
    using DogeNet.BLL.Features.Friends.GetBlackList;
    using DogeNet.BLL.Features.Friends.GetFriendRequests;
    using DogeNet.BLL.Features.Friends.GetFriends;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IMediator mediator;

        public FriendController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<FriendsDetailsModel>))]
        public async Task<IActionResult> GetFriends(int id) =>
            this.Ok(await this.mediator.Send(new GetFriendsQuery(id)));

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<FriendRequestsDetailsModel>))]
        public async Task<IActionResult> GetFriendRequests(int id) =>
            this.Ok(await this.mediator.Send(new GetFriendsQuery(id)));

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<BlackListDetailsModel>))]
        public async Task<IActionResult> GetBlackList(int id) =>
            this.Ok(await this.mediator.Send(new GetBlackListQuery(id)));

        [HttpPost]
        public async Task<IActionResult> AddFriend(AddFriendModel model) =>
            this.Ok(await this.mediator.Send(new AddFriendCommand(model)));

        [HttpDelete]
        public async Task<IActionResult> DeleteFriend(DeleteFriendModel model) =>
            this.Ok(await this.mediator.Send(new DeleteFriendCommand(model)));
    }
}
