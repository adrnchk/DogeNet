import { AccountDetailsModel } from 'src/app/core/api/models';

export interface UserState {
  info: AccountDetailsModel;
}
export const initialState: UserState = {
  info: {
    avatarImg: '',
    bio: '',
    cityId: 0,
    coverImg: '',
    createdAt: '',
    firstName: '',
    id: 0,
    identityId: '',
    lastName: '',
    statusId: 0,
    title: '',
    updatedAt: '',
    userName: '',
  },
};
