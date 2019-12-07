import pygame
import graphics
import random

screen_width = 1280
screen_height = 720

deltax = 20
deltay = 20

locked = [[0 for columns in range(int(screen_width / deltax))] for rows in range(int(screen_height / deltay))]
nono = [[0 for columns in range(int(screen_width / deltax))] for rows in range(int(screen_height / deltay))]



win = pygame.display.set_mode((screen_width, screen_height))
pygame.display.set_caption("Blob 'o Matic")

graphics.draw_grid(win, screen_width, screen_height, deltax, deltay)

i = 0

while(i < 25):
    graphics.draw_point(win, (random.randint(1, screen_width / deltax), random.randint(1, screen_height / deltay)), (deltax, deltay), (128,128,128), locked, nono)
    pygame.time.delay(2500)
    i += 1

pygame.quit()


