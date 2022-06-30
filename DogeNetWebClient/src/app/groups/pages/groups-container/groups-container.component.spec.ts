import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupsContainerComponent } from './groups-container.component';

describe('GroupsContainerComponent', () => {
  let component: GroupsContainerComponent;
  let fixture: ComponentFixture<GroupsContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupsContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
