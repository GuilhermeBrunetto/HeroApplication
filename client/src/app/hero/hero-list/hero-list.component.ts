import { Component, OnInit } from '@angular/core';

export interface Hero {
  id: string;
  name: string;
  powers: string;
  universe: string;
  initial_date: string;
}

const HERO_DATA: Hero[] = [
  {
    id: '1',
    name: 'superman',
    powers: 'superstrengh',
    universe: 'marvel',
    initial_date: '10/01/2020',
  },
  {
    id: '2',
    name: 'bastman',
    powers: 'super rich',
    universe: 'marvel',
    initial_date: '10/01/2020',
  },
  {
    id: '3',
    name: 'spiderman',
    powers: 'web',
    universe: 'marvel',
    initial_date: '10/01/2020',
  },
  {
    id: '5',
    name: 'flash',
    powers: 'superspeed',
    universe: 'marvel',
    initial_date: '10/01/2020',
  },
  {
    id: '4',
    name: 'wonderwoman',
    powers: 'superstrengh',
    universe: 'marvel',
    initial_date: '10/01/2020',
  },
];

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html',
  styleUrls: ['./hero-list.component.css'],
})
export class HeroListComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'name',
    'powers',
    'universe',
    'initial_date',
  ];
  dataSource = HERO_DATA;

  constructor() {}

  ngOnInit(): void {}
}
