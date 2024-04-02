$version = minver -i
docker tag savvyio-docfx:$version jcr.codebelt.net/geekle/sharedkernel-docfx:$version
docker push jcr.codebelt.net/geekle/sharedkernel-docfx:$version