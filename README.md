# AngleInstructor

This is very old project I dug up that I wrote back when I was in Blue Ridge,
probably 6th grade or so. It shows you, step-by-step, how to construct various
angles without a protractor. It still (kind of) works! It won't build now,
but the latest successful Debug build's exe is still there (AngleInstructor/bin/Debug/AngleInstructor.exe)
and that'll work even on a modern version of Windows 10, as long as you run it from there.
Thanks backwards compatability!

If you don't want to download some random kid's program (for some reason), see
[this video](https://youtu.be/DJ7U6NDJL9I) for a small demonstration.

It's really embarassing code, but I'm proud of it. I remember hours spent
thinking through the details of the architecture, since so many of the angles
relied on other angles being created first (60 -> bisect -> 30; or 90 -> bisect the other side -> 135).
I'd recently read Head First Design Patterns, and was maybe going a little overboard.

I did use a library called [GeoLib](http://www.geolib.co.uk/) to do the drawing,
which requires a license to actually use, but the code is available for free for demo purposes,
and it seems it's gone unmaintained for some time anyway. In any case, I hope it's fine
to put it here, since I'm not actually using it for anything in particular except archiving.
However, email me at `eshansingh@gmail.com` if I've really messed up and I'll spend some time
figuring out how to make it a proper dependency instead of just being in the same folder -
I'm not sure if I knew about package management in those days - or just remove it altogether.