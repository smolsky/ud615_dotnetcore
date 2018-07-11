# ud615_dotnetcore

This repo is a result of passing course "Scalable Microservices with Kubernetes". Originally course operates with Go language. This repo contains the same microservices translated to dot net core 2.1. 

## Original course links
- Course: https://classroom.udacity.com/courses/ud615
- Go version: https://github.com/udacity/ud615

## Changes to original

 Not a part of services (in compare with Go version):
 - version handler
 - healthz checker handler
 - readiness handler

 Changes of kubernetes resources description files:
 - memory limit up to 100Mi (consumes ~30MiB ) (yaml)
 - healthz & readiness probe removed (yaml)
 - redirect for nginx (frontend service) was edited (config)
 - docker containers paths were changed 

 # Docker repositories

  - Monolith service: https://hub.docker.com/r/smolsky/ud615_dotnetcore_monolith/
  - Auth service: https://hub.docker.com/r/smolsky/ud615_dotnetcore_auth/
  - Hello service: https://hub.docker.com/r/smolsky/ud615_dotnetcore_hello/

# Service description

- Auth service can be example of basic http authorization. It uses https://github.com/blowdart/idunno.Authentication . And generates JWT token.

- Hello service checks JWT token and answer "Hello".

- Monolith service - it's a combination of both microservices.

