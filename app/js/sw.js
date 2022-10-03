//import { precacheAndRoute } from 'workbox-precaching/precacheAndRoute';
importScripts(
    'https://storage.googleapis.com/workbox-cdn/releases/6.4.1/workbox-sw.js'
  );
  const {precacheAndRoute} = workbox.cacheableResponse; 
  precacheAndRoute([ 
    {url: '/index.html', revision: null},
    {url: '/join.html', revision: null},
    {url: '/offline.html', revision: null},
    {url: '/about.html', revision: null},
    {url: '/js/sw.js', revision: null},
    {url: '/css/milligram.css', revision: null},
    {url: '/images/logo.png', revision: null}
  ]);
