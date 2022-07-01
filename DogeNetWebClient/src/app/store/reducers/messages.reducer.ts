import * as Actions from 'src/app/store/actions/messages.action';
import { initialState, MessagesState } from '../states/MessagesState';
import { createReducer, on } from '@ngrx/store';

export const messagesNode = 'messages';

export const messagesReducer = createReducer(
  initialState,
  on(Actions.SetMessages, (state, { messages }) => ({
    ...state,
    items: messages,
  })),
  on(Actions.AddMessage, (state, { message }) => ({
    ...state,
    items: [...state.items, message],
  })),
  on(Actions.ClearMessages, (state) => ({
    ...state,
    items: initialState.items,
  })),
  on(Actions.EditMessage, (state, { message }) => {
    state.items.forEach((element) => {
      if (element.id === message.id) {
        element = message;
      }
    });
    return state;
  }),
  on(Actions.DeleteMessage, (state, { id }) => {
    let filtered = state.items.filter((val, indx, arr) => val.id !== id);
    return { ...state, items: filtered };
  })
);
