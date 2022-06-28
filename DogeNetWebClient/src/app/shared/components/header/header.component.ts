import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AccountDetailsModel } from 'src/app/core/api/models';
import { selectUser } from 'src/app/store/selectors/user-info.selectors';
import { UserState } from 'src/app/store/states/UserState';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  public user$: Observable<AccountDetailsModel> = this.store.pipe(
    select(selectUser)
  );
  constructor(private store: Store<UserState>) {}

  ngOnInit(): void {}
}
