import * as Actions from 'src/app/actions/conversation.actions';
import { ConversationDetailsModel } from 'src/app/core/api/models';

export interface ConversationsState {
  items: ConversationDetailsModel[];
}

const initialState: ConversationsState = {
  items: new Array<ConversationDetailsModel>(),
};

export const conversationsNode = 'conversations';

export const conversationsReducer = (
  state = initialState,
  action: Actions.All
): ConversationsState => {
  switch (action.type) {
    case Actions.SET_CONVERSATIONS:
      return { ...state, items: action.payload };

    case Actions.ADD_CONVERSATION:
      state.items.unshift(action.payload);
      return state;

    case Actions.DELETE_CONVERSATION:
      return {
        ...state,
        items: state.items.filter(
          (val, indx, arr) => val.id !== action.payload
        ),
      };

    case Actions.CLEAR_CONVERSATIONS:
      return { ...state, items: [] };
    default:
      return state;
  }
};
