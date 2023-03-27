import { Component, OnInit } from '@angular/core';
import { LngLat, MapMouseEvent } from 'maplibre-gl';
import GeoLoc from 'src/app/models/GeoLoc';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss'],
})
export class MapComponent implements OnInit {
  mapStyle = 'https://demotiles.maplibre.org/style.json';
  zoom = 5;
  centerLat = -74.5;
  centerLng = 40;

  showAddDialog: boolean = false;
  postText: string = "";
  loc: LngLat | undefined;

  constructor(public postService: PostService) { }
  
  ngOnInit(): void {
  }

  onDblClick(e: MapMouseEvent) {
    this.showAddDialog = true;
    this.loc = e.lngLat;
    e.preventDefault();
  }

  closeAddDialog = () => {
    this.showAddDialog = false;
    this.loc = undefined;
  }

  addPost(text: string) {
    this.showAddDialog = false;
    if (text && this.loc) {
      this.postService.addPost(text, {longitude: this.loc.lng, latitude: this.loc.lat});
    }
  }

}
