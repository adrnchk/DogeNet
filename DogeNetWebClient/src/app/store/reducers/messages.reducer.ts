import * as Actions from 'src/app/store/actions/messages.action';
import { Dialogue, initialState, MessagesState } from '../states/MessagesState';
import { createReducer, on } from '@ngrx/store';

export const messagesNode = 'messages';

export const messagesReducer = createReducer(
  initialState,
  on(Actions.SetNewDialogue, (state, { id, messages }) => {
    state.items.unshift({
      id: id,
      messages: messages,
    });
    return state;
  }),
  on(Actions.SendMessage, (state, { id, message }) => {
    state.items.forEach((element) => {
      if (element.id === id) {
        element.messages.unshift(message);
      }
    });
    return state;
  }),
  on(Actions.DeleteDialogue, (state, { payload }) => ({
    ...state,
    items: state.items.filter((val, indx, arr) => val.id !== payload),
  })),
  on(Actions.EditMessage, (state, { id, message }) => {
    state.items.forEach((element) => {
      if (element.id === id) {
        element.messages.forEach((mes) => {
          if (mes.id === message.id) {
            mes = message;
          }
        });
      }
    });
    return state;
  }),
  on(Actions.DeleteMessage, (state, { id, message }) => {
    state.items.forEach((element) => {
      if (element.id === id) {
        element.messages = element.messages.filter(
          (val, indx, arr) => val.id !== message.id
        );
      }
    });
    return state;
  })
);
