import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FriendsGridComponent } from './friends-grid.component';

describe('FriendsGridComponent', () => {
  let component: FriendsGridComponent;
  let fixture: ComponentFixture<FriendsGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FriendsGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FriendsGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
