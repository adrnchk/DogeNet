import { createFeatureSelector, createSelector } from '@ngrx/store';
import {
  conversationsNode,
  ConversationsState,
} from '../reducers/conversations.reducer';

export const selectConversationsFeature =
  createFeatureSelector<ConversationsState>(conversationsNode);

export const selectConversations = createSelector(
  selectConversationsFeature,
  (state: ConversationsState) => state.items
);
