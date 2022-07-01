import { createFeatureSelector, createSelector } from '@ngrx/store';
import { MessagesDetailsModel } from 'src/app/core/api/models';
import { messagesNode } from '../reducers/messages.reducer';
import { MessagesState } from '../states/MessagesState';

export const selectMessagesFeature =
  createFeatureSelector<MessagesState>(messagesNode);

export const selectMessages = createSelector(
  selectMessagesFeature,
  (state: MessagesState) => state.items
);
