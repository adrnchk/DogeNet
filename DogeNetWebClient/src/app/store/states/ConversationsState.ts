import { ConversationDetailsModel } from 'src/app/core/api/models';

export interface ConversationsState {
  items: ConversationDetailsModel[];
}

export const initialState: ConversationsState = {
  items: new Array<ConversationDetailsModel>(),
};
