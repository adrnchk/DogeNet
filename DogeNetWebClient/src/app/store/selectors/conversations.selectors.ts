import { createFeatureSelector, createSelector } from '@ngrx/store';
import { conversationsNode } from '../reducers/conversations.reducer';
import { ConversationsState } from '../states/ConversationsState';

export const selectConversationsFeature =
  createFeatureSelector<ConversationsState>(conversationsNode);

export const selectConversations = createSelector(
  selectConversationsFeature,
  (state: ConversationsState) => state.items
);
