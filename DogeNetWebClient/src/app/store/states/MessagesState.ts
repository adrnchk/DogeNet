import { MessagesDetailsModel } from 'src/app/core/api/models';

export interface MessagesState {
  items: Dialogue[];
}
export interface Dialogue {
  id: number;
  messages: MessagesDetailsModel[];
}

export const initialState: MessagesState = {
  items: new Array<Dialogue>(),
};
