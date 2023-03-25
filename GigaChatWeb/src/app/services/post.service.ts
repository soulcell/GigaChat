import { Injectable } from '@angular/core';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { HubConnection } from '@microsoft/signalr/dist/esm/HubConnection';
import GeoLoc from '../models/GeoLoc';
import Post from '../models/Post';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  private readonly connection: HubConnection;

  public posts: Post[] = [];

  constructor(private authService: AuthService) {
    this.connection = new HubConnectionBuilder()
      .withUrl('/api/postHub', {
        accessTokenFactory: () => this.authService.getToken() || '',
      })
      .configureLogging(LogLevel.Debug)
      .build();

    this.connection.on('newPost', (post: Post) => {
      this.posts.push(post);
    });

    this.connection.start().then(() => {
      this.getPosts();
    });
  }

  getPosts() {
    this.connection.invoke('GetPostsAsync').then((result) => {
      this.posts = result;
    });
  }

  addPost(text: string, loc: GeoLoc) {
    const post: Post = {
      text,
      location: loc,
    };
    this.connection.invoke('AddPostAsync', text, loc);
  }
}
