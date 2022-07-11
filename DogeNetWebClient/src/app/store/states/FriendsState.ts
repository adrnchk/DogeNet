import { FriendsDetailsModel } from 'src/app/core/api/models';

export interface FriendsState {
  items: FriendsDetailsModel[];
}
export const initialState: FriendsState = {
  items: new Array<FriendsDetailsModel>(),
};
