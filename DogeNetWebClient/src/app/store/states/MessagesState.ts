import { MessagesDetailsModel } from 'src/app/core/api/models';

export interface MessagesState {
  items: MessagesDetailsModel[];
}

export const initialState: MessagesState = {
  items: new Array<MessagesDetailsModel>(),
};
