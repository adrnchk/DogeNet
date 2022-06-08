import { createFeatureSelector, createSelector } from '@ngrx/store';
import { messagesNode } from '../reducers/messages.reducer';
import { MessagesState } from '../states/MessagesState';

export const selectMessagesFeature =
  createFeatureSelector<MessagesState>(messagesNode);

export const selectDialogues = createSelector(
  selectMessagesFeature,
  (state: MessagesState) => state.items
);
