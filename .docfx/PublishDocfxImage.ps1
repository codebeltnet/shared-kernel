$version = minver -i
docker tag sharedkernel-docfx:$version jcr.codebelt.net/geekle/sharedkernel-docfx:$version
docker push jcr.codebelt.net/geekle/sharedkernel-docfx:$version
