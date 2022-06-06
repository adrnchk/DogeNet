import * as Actions from 'src/app/actions/messages.action';
import { MessagesDetailsModel } from 'src/app/core/api/models';

export interface MessagesState {
  items: Dialogue[];
}
export interface Dialogue {
  id: number;
  messages: MessagesDetailsModel[];
}

const initialState: MessagesState = {
  items: new Array<Dialogue>(),
};

export const messagesNode = 'messages';

export const messagesReducer = (
  state = initialState,
  action: Actions.All
): MessagesState => {
  switch (action.type) {
    case Actions.SET_NEW_DIALOGUE:
      state.items.unshift({
        id: action.payload.id,
        messages: action.payload.messages,
      });
      return state;

    case Actions.SEND_MESSAGE:
      state.items.forEach((element) => {
        if (element.id === action.payload.id) {
          element.messages.unshift(action.payload.message);
        }
      });
      return state;

    case Actions.DELETE_DIALOGUE:
      return {
        ...state,
        items: state.items.filter(
          (val, indx, arr) => val.id !== action.payload
        ),
      };
    case Actions.EDIT_MESSAGE:
      state.items.forEach((element) => {
        if (element.id === action.payload.id) {
          element.messages.forEach((mes) => {
            if (mes.id === action.payload.message.id) {
              mes = action.payload.message;
            }
          });
        }
      });
      return state;

    case Actions.DELETE_MESSAGE:
      state.items.forEach((element) => {
        if (element.id === action.payload.id) {
          element.messages = element.messages.filter(
            (val, indx, arr) => val.id !== action.payload.message.id
          );
        }
      });
      return state;
    default:
      return state;
  }
};
