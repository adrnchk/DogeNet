// <copyright file="UpdateAccountDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.UpdateAccount
{
    public class UpdateAccountDetailsModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string AvatarImg { get; set; }

        public string Bio { get; set; }
    }
}
