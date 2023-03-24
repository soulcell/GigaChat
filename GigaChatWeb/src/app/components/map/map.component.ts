import { Component, OnInit } from '@angular/core';
import { LngLatLike, MapLibreEvent, MapMouseEvent } from 'maplibre-gl';
import { MyMarker } from 'src/app/models/myMarker';
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

  markerPositions: LngLatLike[] = [
    [-13, 20],
    [-14, 11]
  ]

  markers: MyMarker[] = [
    {
      author: "kriper",
      text: "pshhhdsad sda sad  sdfgsadfd fgkmng jfb",
      lngLat: [-13, 20]
    },
    {
      author: "man",
      text: "Hello chez",
      lngLat: [10, 22]
    },
    {
      author: "hols",
      text: "Cool!",
      lngLat: [-3, 44]
    },
    {
      author: "player",
      text: "sdf sda sad  sda fgkmng jfb",
      lngLat: [0, 0]
    },
  ]

  constructor(public postService: PostService) { }
  
  ngOnInit(): void {
  }

  onDblClick(e: MapMouseEvent) {
    const {lng: longitude, lat: latitude} = e.lngLat
    this.postService.addPost({longitude, latitude})
    e.preventDefault();
  }


}
