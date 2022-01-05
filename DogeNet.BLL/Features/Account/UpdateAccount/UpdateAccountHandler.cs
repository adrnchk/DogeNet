// <copyright file="UpdateAccountHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.UpdateAccount
{
    using AutoMapper;
    using DogeNet.BLL.Features.Account.GetAccount;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, AccountDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public UpdateAccountHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AccountDetailsModel> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await this.context.AppUsers.FindAsync(request.model.Id);

            user.FirstName = request.model.FirstName;
            user.LastName = request.model.LastName;
            user.UpdatedAt = DateTime.Now;
            user.Title = request.model.Title;
            user.Bio = request.model.Bio;
            user.AvatarImg = request.model.AvatarImg;

            this.context.SaveChanges();

            return this.mapper.Map<User, AccountDetailsModel>(user);
        }
    }
}
