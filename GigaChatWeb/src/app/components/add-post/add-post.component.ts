import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent {
  @Input() onclose: (() => void) = () => {};
  @Output() addPostEvent = new EventEmitter<string>();

  addPost(text: string) {
    this.addPostEvent.emit(text);
  }
}
