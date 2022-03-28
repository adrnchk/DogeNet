// <copyright file="AccountDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Account.GetAccount
{
    using System;

    public class AccountDetailsModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string IdentityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? StatusId { get; set; }

        public string Title { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int? CityId { get; set; }

        public string Bio { get; set; }
    }
}
