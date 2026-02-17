import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserSearchComponent } from './user-search/user-search.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UserSearchComponent],
  template: '<main class="container"><app-user-search /></main>',
  styles: ['.container { max-width: 800px; margin: 2rem 1rem; padding: 0; text-align: left; }'],
})
export class AppComponent {}
