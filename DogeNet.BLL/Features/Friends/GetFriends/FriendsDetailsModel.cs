// <copyright file="FriendsDetailsModel.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriends
{
    using System;

    public class FriendsDetailsModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? StatusId { get; set; }

        public string Title { get; set; }

        public string AvatarImg { get; set; }

        public string CoverImg { get; set; }

        public int? CityId { get; set; }

        public string Bio { get; set; }
    }
}
