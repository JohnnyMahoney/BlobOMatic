import pygame
import random

pygame.init()

window = pygame.display.set_mode((1280, 720))
pygame.display.set_caption ("Blob 'o Matic")

x = 50
y = 50

width = 40
height = 60

velocity = 5

gameRun = True

while gameRun:
    pygame.time.delay(100)

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            gameRun = False

    keys = pygame.key.get_pressed()

    if keys[pygame.K_LEFT]:
        x -= velocity
    if keys[pygame.K_RIGHT]:
        x += velocity
    if keys[pygame.K_UP]:
        y -= velocity
    if keys[pygame.K_DOWN]:
        y += velocity

    window.fill((0, 0, 0))
    pygame.draw.rect(window, (255, 0, 0), (x, y, width, height))
    pygame.display.update()

pygame.quit()

