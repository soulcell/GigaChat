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
    this.connection.start().then(() => {
      this.getPosts()
    });
  }

  getPosts() {
    this.connection.invoke('GetPostsAsync')
      .then((result) => {
        this.posts = result;
        console.log(result);
      });
  }

  addPost(loc: GeoLoc) {
    const post: Post = {
      id: "0",
      authorId: "0",
      text: "lol",
      location: loc
    }
    this.posts.push(post);
    console.log(post);
    this.connection.invoke('AddPostAsync', 'lolkek', loc);
  }
}
