import { createAction, props } from '@ngrx/store';
import { GroupDetailsModel } from 'src/app/core/api/models';

export const SetGroups = createAction(
  '[Groups] Set_Groups',
  props<{ groups: GroupDetailsModel[] }>()
);
export const AddGroup = createAction(
  '[Groups] Add',
  props<{ group: GroupDetailsModel }>()
);
export const DeleteGroup = createAction(
  '[Groups] Delete',
  props<{ id: number }>()
);
export const ClearGroups = createAction('[Groups] Clear_Groups');
