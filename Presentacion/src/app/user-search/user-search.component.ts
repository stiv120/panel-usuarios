import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-user-search',
  standalone: true,
  imports: [NgIf],
  templateUrl: './user-search.component.html',
  styleUrls: ['./user-search.component.scss'],
})
export class UserSearchComponent {
  users: User[] = [];
  loading = false;
  error: string | null = null;

  constructor(private readonly userService: UserService) {}

  onSearch(): void {
    this.loading = true;
    this.error = null;
    this.userService.getAll().subscribe({
      next: (data) => {
        this.users = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Ha ocurrido un error. Por favor, intente de nuevo.';
        this.loading = false;
      },
    });
  }

  fullName(user: User): string {
    const first = user.firstName ?? '';
    const last = user.lastName ?? '';
    return [first, last].filter(Boolean).join(' ').trim() || '—';
  }
}
