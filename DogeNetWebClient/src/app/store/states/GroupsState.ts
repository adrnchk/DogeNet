import { GroupDetailsModel } from 'src/app/core/api/models';

export interface GroupsState {
  items: GroupDetailsModel[];
}
export const initialState: GroupsState = {
  items: new Array<GroupDetailsModel>(),
};
