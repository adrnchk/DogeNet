// <copyright file="AddFriendModelValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.AddFriend
{
    using DogeNet.DAL;
    using FluentValidation;

    public class AddFriendModelValidator : AbstractValidator<AddFriendModel>
    {
        public AddFriendModelValidator(DBContext context)
        {
            this.RuleFor(enitity => enitity.FriendId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity.UserId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity).NotNull()
                .Must(source =>
                !FriendChecks.IsAlreadyFriends(context, source.UserId, source.FriendId)).WithMessage("Already in friend list")
                .Must(source =>
                !FriendChecks.IsInBlackList(context, source.UserId, source.FriendId)).WithMessage("User is in black list");

        }
    }
}
