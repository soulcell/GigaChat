import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoMessageComponent } from './video-message.component';

describe('VideoMessageComponent', () => {
  let component: VideoMessageComponent;
  let fixture: ComponentFixture<VideoMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VideoMessageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VideoMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
