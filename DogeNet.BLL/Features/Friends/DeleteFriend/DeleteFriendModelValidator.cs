// <copyright file="DeleteFriendModelValidator.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.DeleteFriend
{
    using DogeNet.DAL;
    using FluentValidation;

    public class DeleteFriendModelValidator : AbstractValidator<DeleteFriendModel>
    {
        public DeleteFriendModelValidator(DBContext context)
        {
            this.RuleFor(enitity => enitity.FriendId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity.UserId).NotEmpty().NotNull();
            this.RuleFor(enitity => enitity).NotNull()
                .Must(source =>
                FriendChecks.IsAlreadyFriends(context, source.UserId, source.FriendId)).WithMessage("User is not in the friend list")
                .Must(source =>
                !FriendChecks.IsInBlackList(context, source.UserId, source.FriendId)).WithMessage("User is in black list");
        }
    }
}
